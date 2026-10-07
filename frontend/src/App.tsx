import './styles/main.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'

import LoginPage from './pages/loginPage'
import ToDoPage from './pages/toDoPage'
import RegisterPage from './pages/RegisterPage'

import ProtectedRoute from './components/Routes/ProtectedRoute'
import PublicRoute from './components/Routes/PublicRoute'
function App() {

    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<PublicRoute><LoginPage></LoginPage></PublicRoute>}></Route>
                    <Route path="/todo" element={<ProtectedRoute><ToDoPage></ToDoPage></ProtectedRoute>}></Route>
                    <Route path="/register" element={<PublicRoute><RegisterPage></RegisterPage></PublicRoute>}></Route>

                </Routes>
            </BrowserRouter>
    </>
  )
}

export default App
