import style from "../../styles/athlete-main-page.module.css"
import TrainerLeftPane from "../../components/trainer-view/trainer-left-pane";
import PlansList from "../../components/trainer-view/trainer-plans/plans-list";

const TrainerDashboard = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD", width:"350px"}}>
                <TrainerLeftPane />
            </div>
            <PlansList />
        </div>
    );
}

export default TrainerDashboard;