import DefaultLeftPane from "../../components/reusable-comps/default-left-pane";
import style from "../../styles/athlete-main-page.module.css"
import ApplyTrainingView from "../../components/athlete-view/athlete-training/training-plans/apply-training-view";

const AthleteApplyTraining = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD", width:"350px"}}>
                <DefaultLeftPane />
            </div>
            <ApplyTrainingView />
        </div>
    );
}

export default AthleteApplyTraining;