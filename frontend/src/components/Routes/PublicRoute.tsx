import { Navigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";

function PublicRoute({children,}:{children:React.ReactNode;}){
    const {isLoggedIn} = useAuth();
    if(isLoggedIn){
        return <Navigate to="/todo" replace></Navigate>
    }
    return children;
}

export default PublicRoute;