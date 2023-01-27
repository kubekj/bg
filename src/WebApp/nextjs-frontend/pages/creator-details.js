import DefaultLeftPane from "../components/reusable-comps/default-left-pane";
import style from "../styles/athlete-main-page.module.css"
import CreatorView from "../components/athlete-view/athlete-marketplace/creator-view";

const CreatorDetails = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <CreatorView />
        </div>
    );
}

export default CreatorDetails;