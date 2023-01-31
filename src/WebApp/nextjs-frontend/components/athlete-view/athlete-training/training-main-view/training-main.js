import style from "./training-main.module.css";
import TrainingPlan from "./training-plan";
import LatestWorkouts from "../workouts/latest-workouts";
import LatestExercises from "../athlete-exercises/latest-exercises";


const TrainingMain = ({workouts, exercises, plans}) => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <h2>Training</h2>
                <p>Manage your training data here.</p>
            </div>
            <div className={style.mid}>
                <TrainingPlan
                    plans={plans}
                />
            </div>
            <div className={style.bottom}>
                <LatestWorkouts
                    workouts={workouts}
                />
                <LatestExercises
                    exercises={exercises}
                />
            </div>
        </div>
    );
};

export default TrainingMain;
