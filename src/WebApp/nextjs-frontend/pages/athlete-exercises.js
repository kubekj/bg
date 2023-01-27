import DefaultLeftPane from "../components/athlete-view/reusable-comps/default-left-pane";
import style from "../styles/athlete-main-page.module.css"
import TrainingMain from "../components/athlete-view/athlete-training/training-main-view/training-main";
import TrainingPlansView from "../components/athlete-view/athlete-training/training-plans/training-plans-view";
import ExercisesList from "../components/athlete-view/athlete-training/athlete-exercises/exercises-list";

const AthleteExercises = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <ExercisesList />
        </div>
    );
}

export default AthleteExercises;