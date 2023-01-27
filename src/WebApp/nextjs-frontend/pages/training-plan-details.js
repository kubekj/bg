import DefaultLeftPane from "../components/reusable-comps/default-left-pane";
import style from "../styles/athlete-main-page.module.css";
import TrainingDetailsView
    from "../components/athlete-view/athlete-training/training-plans/training-details/training-details-view";

const TrainingPlanDetails = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <TrainingDetailsView />
        </div>
    );
}

export default TrainingPlanDetails;