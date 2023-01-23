import style from "../styles/athlete-main-page.module.css";
import DefaultLeftPane from "../components/athlete-view/reusable-comps/default-left-pane";
import ExerciseView from "../components/athlete-view/athlete-training/athlete-exercises/exercise-view";

const AddNewExercise = () => {

    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <ExerciseView
                title="Create new exercise"
                btnRightLabel="Add"
            />
        </div>
    );
}

export default AddNewExercise;