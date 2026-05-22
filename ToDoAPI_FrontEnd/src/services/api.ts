const API_URL = "http://localhost:5222/api"


export async function loginApi(username:string, password:string){
    const response = await fetch(`${API_URL}/Auth/login`, {
        method:'post',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            username,
            password
        }),
        
    });

    if (!response.ok){
        throw new Error("Invalid credentials");
    }
    return response.json();
}

export async function registerApi(username:string, password:string){
    const response = await fetch (`${API_URL}/Auth/register`,{
        method:'post',
        headers:{
            "Content-Type":"application/json"
        },
        body: JSON.stringify({
            username:username,
            password:password
        }),
    });

    if(!response.ok){
        throw new Error("User already exists");
    }
}

export async function getMyItems(token:string){
    const response = await fetch(`${API_URL}/toDoItems/my-items`,{
        method: "GET",
        headers:{
            Authorization: `Bearer ${token}`,
        },
    });
    if(!response.ok){
        throw new Error("Failed to fetch items");
    }
    return response.json();}
export async function createItem(taskDesc:string, token:string){
        const response = await fetch(`${API_URL}/toDoItems`, {
        method: "POST",
        headers:{
            "Content-Type":"application/json",
            Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({
            description:taskDesc
        }),
        });

        if(!response.ok){
            throw new Error("Failed to create item");
        }
    }

    export async function deleteItem(id: number, token: string) {

    const response = await fetch(`${API_URL}/toDoItems/${id}`, {
        method: "DELETE",
        headers: {
            Authorization: `Bearer ${token}`,
        },
    });

    if (!response.ok) {
        throw new Error("Failed to delete item");
    }
}