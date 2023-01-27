import style from "../styles/athlete-main-page.module.css";
import DefaultLeftPane from "../components/reusable-comps/default-left-pane";
import ExerciseView from "../components/athlete-view/athlete-training/athlete-exercises/exercise-view";

const EditExercise = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD", width:"350px"}}>
                <DefaultLeftPane />
            </div>
            <ExerciseView
                title="Edit exercise"
                btnRightLabel="Edit"
            />
        </div>
    );
}

export default EditExercise;