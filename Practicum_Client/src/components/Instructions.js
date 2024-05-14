

export default function Instruction() {

    return (
        <div>
            <h2>שלום ל{sessionStorage.getItem('fNameP')} {sessionStorage.getItem('lNameP')}</h2>
            <h4>הנחיות להשלמת הטופס</h4>
            <ul>
                <li>כל השדות הם שדות חובה.</li>
                <li>יש למלא פרטים נכונים בלבד</li>
            </ul>
        </div>
    )
}