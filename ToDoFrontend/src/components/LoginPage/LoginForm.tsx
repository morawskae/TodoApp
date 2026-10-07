import {useState} from "react";
import {useNavigate} from "react-router-dom"
import {loginApi} from "../../services/api" ;
import { useAuth } from "../../context/AuthContext";
function LoginForm() {

    const [username, setUsername]=useState("");
    const [password, setPassword]=useState("");

    const navigate = useNavigate();
    const {login} = useAuth();

    const onRegisterHandle = ()=>{
        navigate("/register");
    }

    async function handleSubmit(e:any){
        e.preventDefault();

        try{
            const data = await loginApi(username,password);
            login(data.token);
            navigate("/todo");
        }
        catch(error){
            console.log(error);
            alert("Login failed");
        }
    }
return (
    <div className="container">
        <form className="form" onSubmit={handleSubmit}>
            <h2>Login</h2>

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

            <button type="submit">
                Log in
            </button>

            <p className="divider">or</p>

            <button
                type="button"
                className="register-btn"
                onClick={onRegisterHandle}
            >
                Register
            </button>
        </form>
    </div>
);}

export default LoginForm;