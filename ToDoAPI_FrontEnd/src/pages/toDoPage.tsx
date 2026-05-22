import { useState, useEffect } from "react";
import ItemBar from "../components/mainPageComponents/ItemBar";
import ItemList from "../components/mainPageComponents/ItemList";
import NavBar from "../components/NavBar";

import { getMyItems, deleteItem } from "../services/api";

type ToDoItem = {
    id:number;
    description:string;
}
function ToDoPage() {

    const [itemList, setItemList] = useState<ToDoItem[]>([]);
    
    const fetchItems = async ()=>{
            try {
                const token = localStorage.getItem("token");
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

        const token = localStorage.getItem("token");

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
                <ItemBar fetchItems={fetchItems}></ItemBar>
                <ItemList itemDescList={itemList} onDeleteItem={deleteTask}></ItemList>
            </div>
        </main>

    </>);
}

export default ToDoPage;