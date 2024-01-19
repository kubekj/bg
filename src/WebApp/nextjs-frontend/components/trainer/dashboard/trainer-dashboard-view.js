import style from "./trainer-dashboard-view.module.css";
import TrainerOverviewView from "./trainer-overview-view";
import TrainerRightPaneView from "./trainer-right-pane-view";


const TrainerDashboardView = () => {

    return (
        <div className={style.container}>
            <div className={style.header}>
                <h2 style={{marginBottom: "1rem"}}>Dashboard</h2>
            </div>
            <div className={style.overview}>
                <TrainerOverviewView/>
                <div style={{borderLeft: "1px solid #D0D5DD", marginLeft: "1rem"}}/>
                <TrainerRightPaneView/>
            </div>
        </div>
    );
}

export default TrainerDashboardView;