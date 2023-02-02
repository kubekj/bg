import { toast } from "react-toastify";

export async function handleError(response) {
  try {
    let message = await response.json();
    toast.error(message.reason);
  } catch (e) {
    toast.error(err.message);
  }
}
