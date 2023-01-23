import DefaultLeftPane from "../components/athlete-view/reusable-comps/default-left-pane";
import style from "../styles/athlete-main-page.module.css";
import TrainingAddView
    from "../components/athlete-view/athlete-training/training-plans/training-details/training-add-view";

const AddNewTraining = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <TrainingAddView />
        </div>
    );
}

export default AddNewTraining;