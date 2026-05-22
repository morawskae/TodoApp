import { useState, useEffect } from "react";
import ItemBar from "../components/mainPageComponents/ItemBar";
import ItemList from "../components/mainPageComponents/ItemList";
import NavBar from "../components/NavBar";
import { useAuth } from "../context/AuthContext";

import { getMyItems, deleteItem } from "../services/api";

type ToDoItem = {
    id:number;
    description:string;
}
function ToDoPage() {

    const {token} = useAuth();
    const [itemList, setItemList] = useState<ToDoItem[]>([]); 
    const fetchItems = async ()=>{
            try {
                const data = await getMyItems(token!);
                console.log("API DATA",data);
                setItemList(data);

            }
            catch(error){
                console.log(error)
            }
        };
    useEffect(()=>{
        fetchItems();
    },[]);
    

const deleteTask = async (taskId: number) => {

    try {
        await deleteItem(taskId, token!);
        await fetchItems();

    } catch (error) {

        console.log(error);
    }
};

    return (<>
        <header>
            <NavBar></NavBar>
        </header>

        <main>
            <div className="toDo-div">
                <h3> To-do List:</h3>
                <ItemBar fetchItems={fetchItems}></ItemBar>
                <ItemList itemDescList={itemList} onDeleteItem={deleteTask}></ItemList>
            </div>
        </main>

    </>);
}

export default ToDoPage;