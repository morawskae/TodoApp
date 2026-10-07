
import '../../styles/item.css'
import deleteIcon from '../../assets/delete-icon.svg'
import checkMark from '../../assets/check_mark.svg'
import { useState } from 'react';

import { useAuth } from "../../context/AuthContext";
import {updateItem} from "../../services/api";
type ItemProps = {
    taskDesc: string;
    onDeleteItem: (itemIndex: number) => void;
    itemId: number;
    isFinished:boolean;
};

// add updateAPI function 



function Item({ taskDesc, onDeleteItem,itemId,isFinished}: ItemProps) {
    console.log("ITEM ID:", itemId)
    const [isTaskFinished, setIsTaskFinished] = useState(isFinished);
    const {token} = useAuth();
    const onUpdateHandle = async ()=>{
        try{
            await updateItem(itemId,token!,taskDesc,!isTaskFinished);
            setIsTaskFinished(!isTaskFinished)
        }
        catch(error){
            console.log(error);

        }
        
    };

    return (

        <div className="item_div">
            <button className={"is_finished_button"+ (isTaskFinished?"-active":"")} onClick ={onUpdateHandle}> <img src={checkMark} alt = "some text" className='is_finished_button_img'/></button>
            <p className={"taskDesc_p" + (isTaskFinished?" taskDesc_p-finished":"")}>  {taskDesc}</p>
            <div className="item_button_div">
                <button className="delete_task_btn" onClick={()=>(onDeleteItem(itemId)) }> <img className = "delete_task_btn_icon" src={deleteIcon} alt = "delete task"/> </button>
            </div>
        </div>)
}

export default Item; 