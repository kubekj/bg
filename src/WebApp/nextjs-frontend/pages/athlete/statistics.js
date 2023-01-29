import style from "../styles/athlete-main-page.module.css";
import DefaultLeftPane from "../components/reusable-comps/default-left-pane";
import StatisticsView from "../components/athlete-view/athlete-statistics/statistics-view";

const AthleteStatistics = () => {
  return (
    <div className={style.container}>
      <div style={{ borderRight: "1px solid #D0D5DD", width: "350px" }}>
        <DefaultLeftPane />
      </div>
      <StatisticsView />
    </div>
  );
};

export default AthleteStatistics;
