
import '../../styles/item.css'

type ItemProps = {
    taskDesc: string;
    onDeleteItem: (itemIndex: number) => void;
    itemId: number;
};
function Item({ taskDesc, onDeleteItem,itemId }: ItemProps) {
    console.log("ITEM ID:", itemId)
    return (
        <div className="item_div">
            <p className="taskDesc_p"> { taskDesc}</p>
            <button className="delete_task_btn" onClick={()=>(onDeleteItem(itemId)) }> Delete Task </button>
        </div>)
}

export default Item; 