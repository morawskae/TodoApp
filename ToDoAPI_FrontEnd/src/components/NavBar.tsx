
import '../styles/navbar.css'
import { Link } from "react-router-dom";
import '../styles/loginForm.css'
function NavBar() {
    return (
        <nav className="navbar">
            <div className="navbar-left">
                <h1>ToDoApi</h1>
                <h2>First frontend app</h2>
            </div>

            <div className="navbar-links">
                <Link to="/todo"> Home </Link>
                <Link to="/"> Login Page</Link>

            </div>
        </nav>
    );
}

export default NavBar