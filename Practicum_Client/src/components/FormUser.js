import { useForm } from 'react-hook-form';
import axios from 'axios'
import React, { useState, useContext, useEffect } from 'react';
import Field from './Field'
import { useNavigate } from 'react-router-dom'

export default function FormUser() {
    var ans;
    var usersArr;
    var childrenArr;
    const navigateItem = useNavigate()
    const { register, handleSubmit, formState: { errors } } = useForm();
    const [child, setChild] = useState(0)
    const [fields, setFields] = useState([])
    const [finish, setFinish] = useState(false)

    const handleRegistration = async (data) => {
        var flag = true
        for (let i = 0; i < sessionStorage.getItem('numChild'); i++) {
            if (sessionStorage.getItem(`Name${i}`) === null
                || sessionStorage.getItem(`TZ${i}`) === null
                || sessionStorage.getItem(`DateOfBirth${i}`) === null) {
                alert('כל השדות הם שדות חובה!')
                flag = false
            }
        }
        if (flag) {
            console.log("data form", data)
            //טיפול בפרטי ההורה
            const obj = {
                FirstName: data.firstName,
                LastName: data.lastName,
                TZ: data.tz,
                DateOfBirth: data.dateOfBirth,
                Kind: parseInt(data.kind),
                HMO: parseInt(data.hmo)
            }
            usersArr = await axios.get('https://localhost:44381/User')
            console.log("usersArr", usersArr.data)
            var isExists = usersArr.data.find(p => p.tz === data.tz)
            if (isExists === undefined) {//אם תעודת הזהות שהוזנה לא קיימת
                ans = await axios.post('https://localhost:44381/User', obj)
            }
            else {//אם תעודת הזהות שהוזנה קיימת
                ans = await axios.put(`https://localhost:44381/User/${isExists.id}`, obj)
            }
            //טיפול בפרטי הילדים
            console.log("ans", ans)
            for (let i = 0; i < sessionStorage.getItem('numChild'); i++) {
                const current = {
                    Name: sessionStorage.getItem(`Name${i}`),
                    TZ: sessionStorage.getItem(`TZ${i}`),
                    DateOfBirth: sessionStorage.getItem(`DateOfBirth${i}`),
                }
                if (ans.data.kind === 1)
                    current.IdParent1 = ans.data.id
                else if (ans.data.kind === 2)
                    current.IdParent2 = ans.data.id
                console.log("current", current)
                childrenArr = await axios.get('https://localhost:44381/Child')
                var childExists = childrenArr.data.find(p => p.tz === current.TZ)
                if (childExists === undefined) {
                    axios.post(`https://localhost:44381/Child`, current)
                        .then(res => console.log(res.data))
                        .catch(error => console.log(error))
                }
                else {
                    if (childExists.idParent1 !== null)
                        current.IdParent1 = childExists.idParent1
                    if (childExists.idParent2 !== null)
                        current.IdParent2 = childExists.idParent2
                    axios.put(`https://localhost:44381/Child/${childExists.id}`, current)
                        .then(res => console.log(res.data))
                        .catch(error => console.log(error))
                }
            }
            setFinish(true)
        }
    }

    useEffect(() => {
        const arr = []
        for (let i = 0; i < sessionStorage.getItem('numChild'); i++) {
            arr.push(<div key={i}><Field id={i} /></div>);
        }
        setFields(arr)
    }, [child])

    return (
        <div>
            <h4>פרטי הורה</h4>
            <form onSubmit={handleSubmit(handleRegistration)} dir="rtl" 
                style={{ width: "100%" }}  >
                <div className='input-group mb-3'>
                    <span className='input-group-text'>שם פרטי</span>
                    <input name="firstName" className="form-control" placeholder="שם פרטי" type="text"
                        defaultValue={sessionStorage.getItem('fNameP')}
                        {...register('firstName', {
                            required: "שדה חובה", onChange: event => { sessionStorage.setItem('fNameP', event.target.value) }
                        })}
                    />
                    {errors?.firstName && <div >{errors.firstName.message}</div>}
                </div>
                <div className='input-group mb-3'>
                    <span className='input-group-text'>שם משפחה</span>
                    <input name="lastName" className="form-control" placeholder="שם משפחה" type="text"
                        defaultValue={sessionStorage.getItem('lNameP')}
                        {...register('lastName', {
                            required: "שדה חובה",
                            onChange: event => { sessionStorage.setItem('lNameP', event.target.value) }
                        })} />
                    {errors?.lastName && <p >{errors.lastName.message}</p>}
                </div >
                <div className='input-group mb-3'>
                    <span className='input-group-text'>ת.ז.</span>
                    <input name="tz" className="form-control" placeholder="ת.ז." type="text"
                        defaultValue={sessionStorage.getItem('tzP')}
                        {...register('tz', {
                            required: "שדה חובה", minLength: 9, maxLength: 9,
                            onChange: event => { sessionStorage.setItem('tzP', event.target.value) }
                        })} />
                    {errors?.tz?.type === "required" && <p >{errors.tz.message}</p>}
                    {errors?.tz?.type === 'minLength' && <p >אורך מינימלי 9 </p>}
                    {errors?.tz?.type === 'maxLength' && <p >אורך מקסימלי 9 </p>}
                </div>
                <div className='input-group mb-3'>
                    <span className='input-group-text'>תאריך לידה</span>
                    <input type="date" name="dateOfBirth" className="form-control"
                        defaultValue={sessionStorage.getItem('dateP')}
                        {...register('dateOfBirth', {
                            required: "שדה חובה",
                            onChange: event => { sessionStorage.setItem('dateP', event.target.value) }
                        })} />
                    {errors?.dateOfBirth && <p >{errors.dateOfBirth.message}</p>}
                </div>
                <div className='input-group mb-3'>
                    <label className='input-group-text'>מין</label>
                    <select className='form-select' name="kind"
                        defaultValue={sessionStorage.getItem('kindP')}
                        {...register('kind', {
                            required: "שדה חובה",
                            onChange: event => { sessionStorage.setItem('kindP', event.target.value) }
                        })}>
                        <option selected>בחר...</option>
                        <option value="1">זכר</option>
                        <option value="2">נקבה</option>
                    </select>
                    {errors?.kind && <p >{errors.kind.message}</p>}
                </div>
                <div className='input-group mb-3'>
                    <label className='input-group-text'>קופת חולים</label>
                    <select className='form-select' name="hmo"
                        defaultValue={sessionStorage.getItem('hmoP')}
                        {...register('hmo', {
                            required: "שדה חובה",
                            onChange: event => { sessionStorage.setItem('hmoP', event.target.value) }
                        })}>
                        <option selected>בחר...</option>
                        <option value="1">מכבי</option>
                        <option value="2">כללית</option>
                        <option value="3">מאוחדת</option>
                        <option value="4">לאומית</option>
                    </select>
                    {errors?.hmo && <p >{errors.hmo.message}</p>}
                </div>
                <div className='input-group mb-3'>
                    <span className='input-group-text'>מס' ילדים</span>
                    <input name="children" className="form-control" type="number"
                        defaultValue={sessionStorage.getItem('numChild')}
                        {...register('children', {
                            required: "שדה חובה", min: 0,
                            onChange: e => {
                                setChild(parseInt(e.currentTarget.value, 10));
                                sessionStorage.setItem("numChild", parseInt(e.currentTarget.value, 10))
                            }
                        })}
                    />
                    {errors?.children?.type === "required" && <p >{errors.children.message}</p>}
                    {errors?.children?.type === "min" && <p >מינימום 0</p>}
                </div>
                {fields}
                <div className='mb-3'>
                    <input className='' type="submit" value="שמירה" />
                </div>
            </form>
            {
                finish && navigateItem('/Finish')
            }
        </div>
    )
}