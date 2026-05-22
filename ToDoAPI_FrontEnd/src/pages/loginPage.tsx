import NavBar from "../components/NavBar";
import LoginForm from "../components/LoginPage/LoginForm"
function LoginPage() {

    return (
        <>
            <header>
                <NavBar></NavBar>
            </header>
            <main>
                <LoginForm>
                </LoginForm>
            </main>
        </>
    );
}
export default LoginPage