import './styles/main.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'

import LoginPage from './pages/loginPage'
import ToDoPage from './pages/toDoPage'
function App() {

    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={ <LoginPage></LoginPage>}></Route>
                    <Route path="/todo" element={<ToDoPage></ToDoPage>}></Route>

                </Routes>
            </BrowserRouter>
    </>
  )
}

export default App
