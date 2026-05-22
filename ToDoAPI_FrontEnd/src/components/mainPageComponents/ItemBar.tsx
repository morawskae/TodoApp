
import { useState} from 'react'
import { createItem } from '../../services/api';
interface Props {

    fetchItems: () => void;
}
 function ItemBar({ fetchItems }: Props) {

    const [newItem, setNewItem] = useState("");
    const onSubmit = async (e:any) => {
        e.preventDefault();
        if (newItem.trim()) {
            try{
            await createItem(newItem, localStorage.getItem("token")!)
            await fetchItems();
            setNewItem("");
        }
            catch(error){
                console.log(error)
            }

        }
    };
    return (
        <>
            <form onSubmit={onSubmit }>
                <h3> To-do List:</h3>
                <input type="text" placeholder="add item to do..." value={newItem} onChange={(e)=>setNewItem(e.target.value) }></input>
                <button type="submit"> Add item </button>
            </form>
        </>);
}

export default ItemBar;