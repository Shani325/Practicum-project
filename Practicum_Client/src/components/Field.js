import { useForm } from 'react-hook-form';

export default function Field({ id }) {    

    const { register, formState: { errors } } = useForm();

    return (
        <div key={id}>
            <h4>ילד {id + 1}</h4>
            <div className='input-group mb-3'>
                <span className='input-group-text'>שם</span>
                <input name={`Name${id}`} placeholder="שם פרטי" type="text" className="form-control"
                    defaultValue={sessionStorage.getItem(`Name${id}`)}
                    {...register(`Name${id}`, {
                        required: "שדה חובה", onChange: event => { sessionStorage.setItem(`Name${id}`, event.target.value) }
                    })}
                />
            </div >
            <div className='input-group mb-3'>
                <span className='input-group-text'>ת.ז.</span>
                <input name={`TZ${id}`} placeholder="ת.ז." type="text" className="form-control"
                    defaultValue={sessionStorage.getItem(`TZ${id}`)}
                    {...register(`TZ${id}`, {
                        required: "שדה חובה", onChange: event => { sessionStorage.setItem(`TZ${id}`, event.target.value) }
                    })}
                />
            </div>
            <div className='input-group mb-3'>
                <span className='input-group-text'>תאריך לידה</span>
                <input name={`DateOfBirth${id}`} type="date" className="form-control"
                    defaultValue={sessionStorage.getItem(`DateOfBirth${id}`)}
                    {...register(`DateOfBirth${id}`, {
                        required: "שדה חובה", onChange: event => { sessionStorage.setItem(`DateOfBirth${id}`, event.target.value) }
                    })}
                />
            </div>
        </div>
    )
}