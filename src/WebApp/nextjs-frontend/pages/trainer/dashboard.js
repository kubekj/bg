import style from "../../styles/athlete-main-page.module.css";
import TrainerDashboardView from "../../components/trainer/dashboard/trainer-dashboard-view";
import TrainerSidebar from "../../components/trainer/sidebar";

const TrainerDashboard = () => {
  return (
    <div className={style.container}>
      <div style={{ borderRight: "1px solid #D0D5DD", width: "350px" }}>
        <TrainerSidebar />
      </div>
      <TrainerDashboardView />
    </div>
  );
};

export default TrainerDashboard;
