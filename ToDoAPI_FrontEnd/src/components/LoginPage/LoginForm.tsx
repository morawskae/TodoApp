import {useState} from "react";
import {useNavigate} from "react-router-dom"
import {login} from "../../services/api" ;
function LoginForm() {

    const [username, setUsername]=useState("");
    const [password, setPassword]=useState("");

    const navigate = useNavigate();

    async function handleSubmit(e:any){
        e.preventDefault();

        try{
            const data = await login(username,password);
            localStorage.setItem("token",data.token);
            navigate("/todo");
        }
        catch(error){
            console.log(error);
            alert("Login failed");
        }
    }
    return (
        <div className="login-container">
            <form className="login-form" onSubmit={handleSubmit}>
                <h2>Login</h2>

                <input
                    type="text"
                    placeholder="Enter your username"
                    value = {username}
                    onChange={(e)=>setUsername(e.target.value)}
                />

                <input
                    type="password"
                    placeholder="Enter your password"
                    value = {password}
                    onChange={(e)=>setPassword(e.target.value)}
                />

                <button type="submit">
                    Log in
                </button>
            </form>
        </div>
    );
}

export default LoginForm;