import DefaultLeftPane from "../components/athlete-view/default-left-pane";
import style from "../styles/athlete-main-page.module.css"
import DashboardMain from "../components/athlete-view/athlete-dashboard/dashboard-main";
import TrainingMain from "../components/athlete-view/athlete-training/training-main";

const AthleteMainPage = () => {

    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            {/*<DashboardMain />*/}
            <TrainingMain />
        </div>
    );
}

export default AthleteMainPage;