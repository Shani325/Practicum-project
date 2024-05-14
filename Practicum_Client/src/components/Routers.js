import { Link, Route, Routes } from "react-router-dom";
import Finish from "./Finish";
import FormUser from "./FormUser";
import Instruction from "./Instructions";

export default function Routers() {

    return (
        <div className="nav justify-content-center">
            <h1>ברוכים הבאים</h1>
            <div className="container-fluid">
                <ul className="nav justify-content-center nav-pills">
                    <li className="nav-item"><Link to='/FormUser' action="result" className="nav-link ">לטופס</Link></li>
                    <li className="nav-item"><Link to='/Instructins' action="result" className="nav-link ">הנחיות להשלמת הטופס</Link></li>
                </ul>
            </div>
            <Routes>
                <Route path="/FormUser" element={<FormUser />}></Route>
                <Route path="/Instructins" element={<Instruction />}></Route>
                <Route path="/Finish" element={<Finish />}></Route>
            </Routes>
        </div>
    )
}