import style from "./training-main.module.css";
import TodayTraining from "../athlete-dashboard/today-training";
import TomorrowTraining from "../athlete-dashboard/tomorrow-training";
import TrainingPlan from "./training-plan";
import PreviousTraining from "./previous-training";
import WorkoutPlainInfo from "./workout-plain-info";

const TrainingMain = () => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <h2>Training</h2>
                <p>Manage your training data here.</p>
            </div>
            <div className={style.mid}>
                <TrainingPlan />
            </div>
            <div className={style.header2}>
                <h2>What's planned for today</h2>
                <p>Today's training type</p>
            </div>
            <div className={style.bottom}>
                <PreviousTraining />
                <WorkoutPlainInfo />
            </div>
        </div>
    );
}

export default TrainingMain;