import {useState} from "react";
import {useNavigate} from "react-router-dom"
import {registerApi} from "../../services/api" ;

import '../../styles/loginForm.css'
function RegisterForm() {

    const [username, setUsername]=useState("");
    const [password, setPassword]=useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    const navigate = useNavigate();

    async function handleSubmit(e:any){
        e.preventDefault();
        if (username.trim() === "") {
             alert("username can't be empty");
             return;}

        if(password.trim()==="" || confirmPassword.trim()==="") {
            alert("password cant be empty");
            return;
        }
        if(confirmPassword!==password){
            alert("passwords dont match")
            setPassword("");
            setConfirmPassword("");
            return;
        }

        try{
            await registerApi(username,password);
            setUsername("");
            setPassword("");
            setConfirmPassword("");
            navigate("/");
        }
        catch(error:any){
            console.log(error);
            alert(error.message);
        }
    }
return (
    <div className="container">
        <form className="form" onSubmit={handleSubmit}>
            <h2>Register</h2>

            <input
                type="text"
                placeholder="Enter your username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
            />

            <input
                type="password"
                placeholder="Enter your password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            
            <input
                type="password"
                placeholder="Confirm your password"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
            />

            <button type="submit">
                Register
            </button>

        </form>
    </div>
);}

export default RegisterForm;