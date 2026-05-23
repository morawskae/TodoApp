import Item from '../mainPageComponents/Item';
import '../../styles/itemList.css'
type ToDoItem = {
    id:number;
    description:string;
    isFinished:boolean;
}

interface ItemListProps {
    itemDescList: ToDoItem[];
    onDeleteItem: (itemId: number) => void;
}

function ItemList({ itemDescList, onDeleteItem }: ItemListProps) {

    return (
        <div className="itemList-div">

            {itemDescList.map((item) => (

                <Item
                    key={item.id}
                    itemId={item.id}
                    taskDesc={item.description}
                    onDeleteItem={onDeleteItem}
                    isFinished={item.isFinished}
                />

            ))}

        </div>
    );
}

export default ItemList;