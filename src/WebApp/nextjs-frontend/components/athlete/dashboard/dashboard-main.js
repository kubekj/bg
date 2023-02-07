import style from "./dashboard-main.module.css";
import WeightBreakdown from "./weight-breakdown";
import HoursTrained from "./hours-trained";
import TomorrowTraining from "./tomorrow-training";
import TodayWorkout from "./today-workout";


const DashboardMain = ({current, next, previous, weightBreakdown, doneTrainings}) => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <h2>Dashboard</h2>
                <p>You can find the most important info here</p>
            </div>
            <div className={style.mid}>
                <WeightBreakdown weightBreakdown={weightBreakdown}/>
                <HoursTrained doneTrainings={doneTrainings}/>
            </div>
            <div className={style.header2}>
                <h2>What's planned for today</h2>
                <p>Today's training type</p>
            </div>
            <div className={style.bottom}>
                <TodayWorkout current={current}/>
                <div className={style.todayTomorrow}>
                    <div style={{marginBottom:"2rem"}}>
                        {next && <TomorrowTraining workout={next} title="Next"/>}
                    </div>
                    <div>
                        {previous &&<TomorrowTraining workout={previous} title="Previous"/>}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default DashboardMain;
