import { createContext, useContext,useEffect,useState } from "react";

type AuthContextType = {
    token: string| null;
    isLoggedIn: boolean;
    login: (token:string)=>void;
    logout: ()=>void
}

const AuthContext = createContext<AuthContextType |undefined>(undefined);

export function AuthProvider({children}:{children: React.ReactNode}){
    const [token, setToken] = useState<string | null>(
    localStorage.getItem("token"));
    const isLoggedIn = !!token; 

    const login = (newToken:string)=>{
        localStorage.setItem("token",newToken);
        setToken(newToken);
    }

    const logout = ()=>{
        localStorage.removeItem("token");
        setToken(null);
    }

    return (
        <AuthContext.Provider value = {{token, isLoggedIn, login,logout}}>
            {children}
        </AuthContext.Provider>
    )

}

export function useAuth(){
    const context = useContext(AuthContext)
    if(!context){
        throw new Error("useAuth must be used inside AuthProvider")
    }
    return context;
}