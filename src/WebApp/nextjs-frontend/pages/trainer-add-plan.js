import style from "../styles/athlete-main-page.module.css"
import TrainerLeftPane from "../components/trainer-view/trainer-left-pane";
import AddPlanView from "../components/trainer-view/trainer-plans/add-plan-view";

const TrainerAddPlan = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD", width:"350px"}}>
                <TrainerLeftPane />
            </div>
            <AddPlanView />
        </div>
    );
}

export default TrainerAddPlan;