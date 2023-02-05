import style from "../styles/athlete-main-page.module.css"
import CreatorView from "../components/athlete/marketplace/creator-view";
import Sidebar from "../components/reusable/sidebar";



const CreatorDetails = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD", width:"350px"}}>
                <Sidebar />
            </div>
            <CreatorView />
        </div>
    );
}

export default CreatorDetails;