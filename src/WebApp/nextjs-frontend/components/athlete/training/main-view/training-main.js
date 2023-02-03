import style from "./training-main.module.css";
import LatestWorkouts from "../workouts/latest-workouts";
import LatestExercises from "../exercises/latest-exercises";
import LatestPlans from "../training-plans/latests-plans";

const TrainingMain = ({ workouts, exercises, plans }) => {
  return (
    <div className={style.container}>
      <div className={style.header}>
        <h2>Training</h2>
        <p>Manage your training data here.</p>
      </div>
      <div className={style.mid}>
        <LatestPlans plans={plans} />
      </div>
      <div className={style.bottom}>
        <LatestWorkouts workouts={workouts} />
        <LatestExercises exercises={exercises} />
      </div>
    </div>
  );
};

export default TrainingMain;
