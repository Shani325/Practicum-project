import { useEffect } from "react"

export default function Finish() {

    useEffect( () => {
        sessionStorage.setItem('fNameP', '')
        sessionStorage.setItem('lNameP', '')
        sessionStorage.setItem('dateP', '')
        sessionStorage.setItem('tzP', '')
        sessionStorage.setItem('kindP', '')
        sessionStorage.setItem('hmoP', '')
        for (let i = 0; i < sessionStorage.getItem('numChild'); i++) {
            sessionStorage.setItem(`Name${i}`, '')
            sessionStorage.setItem(`TZ${i}`, '')
            sessionStorage.setItem(`DateOfBirth${i}`, '')
        }
        sessionStorage.setItem('numChild', 0)
    },[])

    return (
        <div >
            <h6 >נרשמת בהצלחה!</h6>            
        </div>
    )
}