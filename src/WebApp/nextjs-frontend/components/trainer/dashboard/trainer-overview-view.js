import style from "./trainer-overview-view.module.css";
import React from "react";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import { Bar } from "react-chartjs-2";
import faker from "faker";

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);

export const options = {
  responsive: true,
  plugins: {
    legend: {
      display: false,
      position: "bottom",
    },
    title: {
      display: false,
      text: "Chart.js Bar Chart",
    },
  },
  scales: {
    y: {
      title: {
        display: true,
        text: "Active users",
      },
    },
    x: {
      title: {
        display: true,
        text: "Month",
      },
      grid: {
        display: false,
      },
    },
  },
};

const labels = ["January", "February", "March", "April", "May", "June"];
const actuaLabels = ["January", "February"];

export const data = {
  labels,
  datasets: [
    {
      label: "Views",
      data: actuaLabels.map(() => faker.datatype.number({ min: 0, max: 3 })),
      backgroundColor: "#C7D7FE",
    },
  ],
};

const TrainerOverviewView = () => {
  return (
    <div className={style.container}>
      <div className={style.header}>
        <h4>Overview</h4>
        <p style={{ marginBottom: "2rem" }}>
          Manage and track your trainer experience
        </p>
      </div>
      <div className={style.mainPhoto}></div>
      <div className={style.overview}>
        <h5 style={{ marginBottom: "1rem" }}>Overview</h5>
        <div style={{ borderTop: "1px solid #D0D5DD", marginBottom: "1rem" }} />
        <div className={style.props}>
          <p className={style.paragraph}>Current trainees</p>
          <p>1</p>
        </div>
        <div className={style.props}>
          <p className={style.paragraph}>Trainings published</p>
          <p>3</p>
        </div>
        <div className={style.props}>
          <p className={style.paragraph}>Trainings sold</p>
          <p>1</p>
        </div>
        <h5 style={{ marginTop: "1rem" }}>Profile views over time</h5>
        <div style={{ borderTop: "1px solid #D0D5DD", marginTop: "1rem" }} />
        <Bar options={options} data={data} />
      </div>
    </div>
  );
};

export default TrainerOverviewView;
