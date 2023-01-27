import DefaultLeftPane from "../components/reusable-comps/default-left-pane";
import style from "../styles/athlete-main-page.module.css";
 import TrainingDetailsMoreView
    from "../components/athlete-view/athlete-training/training-plans/training-details/training-details-more-view";
import TrainingDetailsViewonlyView
    from "../components/athlete-view/athlete-training/training-plans/training-details/training-details-viewonly-view";
import TrainingInProgress
    from "../components/athlete-view/athlete-training/training-plans/training-details/training-in-progress";

const TrainingDetailsMore = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            {/*<TrainingDetailsMoreView />*/}
            {/*<TrainingDetailsViewonlyView />*/}
            <TrainingInProgress />
        </div>
    );
}

export default TrainingDetailsMore;