import style from "../../styles/athlete-main-page.module.css";
import PlansList from "../../components/trainer/plans/plans-list";
import Trainer from "../../components/layouts/Trainer";

const TrainerDashboard = () => {
  return (
    <div className={style.container}>
      <PlansList />
    </div>
  );
};

export default TrainerDashboard;

TrainerDashboard.layout = Trainer;
