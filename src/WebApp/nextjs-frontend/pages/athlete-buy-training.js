import DefaultLeftPane from "../components/athlete-view/reusable-comps/default-left-pane";
import style from "../styles/athlete-main-page.module.css"
import BuyTrainingView from "../components/athlete-view/athlete-marketplace/buy-training-view";

const AthleteBuyTraining = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <BuyTrainingView />
        </div>
    );
}

export default AthleteBuyTraining;