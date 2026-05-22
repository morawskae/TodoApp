
import '../styles/navbar.css'
import { Link, useNavigate } from "react-router-dom";
import '../styles/loginForm.css'
import { useAuth } from '../context/AuthContext';
function NavBar() {
    const {isLoggedIn, logout} = useAuth();
    const navigate = useNavigate();
    const handleLogout = ()=>{
        logout();
        navigate("/");
    }
    return (
        <nav className="navbar">
            <div className="navbar-left">
                <h1>ToDoApi</h1>
                <h2>First frontend app</h2>
            </div>

            <div className="navbar-links">
                {
                    isLoggedIn? (
                        <button onClick={handleLogout} className="navbar-btn">
                            Log out
                        </button>
                    ):(
                        <Link to ="/">Log in</Link>
                    )
                }

            </div>
        </nav>
    );
}

export default NavBar