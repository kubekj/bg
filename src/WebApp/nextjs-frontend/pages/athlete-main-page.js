import DefaultLeftPane from "../components/reusable-comps/default-left-pane";
import style from "../styles/athlete-main-page.module.css"
import DashboardMain from "../components/athlete-view/athlete-dashboard/dashboard-main";
import TrainingMain from "../components/athlete-view/athlete-training/training-main-view/training-main";
import {useEffect} from "react";

const AthleteMainPage = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <DashboardMain />
        </div>
    );
}

export default AthleteMainPage;