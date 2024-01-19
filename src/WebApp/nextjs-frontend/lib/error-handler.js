import {toast} from "react-toastify";

export default async function handleError(response) {
    try {
        let message = await response.json();
        toast.error(message.reason);
    } catch (e) {
        toast.error(e.message);
    }
}
