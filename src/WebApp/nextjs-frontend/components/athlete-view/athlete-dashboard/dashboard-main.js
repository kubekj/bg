import style from "./dashboard-main.module.css"
import WeightBreakdown from "./weight-breakdown";
import HoursTrained from "./hours-trained";
import TodayTraining from "./today-training";
import TomorrowTraining from "./tomorrow-training";


const DashboardMain = () => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <h2>Dashboard</h2>
                <p>You can find the most important info here</p>
            </div>
            <div className={style.mid}>
                <WeightBreakdown />
                <HoursTrained />
            </div>
            <div className={style.header2}>
                <h2>What's planned for today</h2>
                <p>Today's training type</p>
            </div>
            <div className={style.bottom}>
                <TodayTraining />
                <TomorrowTraining />
            </div>
        </div>
    );
}

export default DashboardMain;