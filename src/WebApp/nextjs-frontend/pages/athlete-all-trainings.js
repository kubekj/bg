import DefaultLeftPane from "../components/reusable-comps/default-left-pane";
import style from "../styles/athlete-main-page.module.css"
import TrainingMain from "../components/athlete-view/athlete-training/training-main-view/training-main";
import TrainingPlansView from "../components/athlete-view/athlete-training/training-plans/training-plans-view";

const AthleteAllTrainings = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <TrainingPlansView />
        </div>
    );
}

export default AthleteAllTrainings;