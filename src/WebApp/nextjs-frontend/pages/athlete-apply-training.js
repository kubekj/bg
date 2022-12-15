import DefaultLeftPane from "../components/athlete-view/default-left-pane";
import style from "../styles/athlete-main-page.module.css"
import ApplyTrainingView from "../components/athlete-view/athlete-training/training-plans/apply-training-view";

const AthleteApplyTraining = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <ApplyTrainingView />
        </div>
    );
}

export default AthleteApplyTraining;