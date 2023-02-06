import style from "../dashboard/dashboard-main.module.css";
//import style from "./statistics-view-module.css" czemu to nie działa? xd
import React from "react";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  LineElement,
  PointElement,
  BarElement,
  Title,
  Filler,
  ArcElement,
  Tooltip,
  Legend,
} from "chart.js";
import { Bar, Doughnut, Line } from "react-chartjs-2";
import faker from "faker";

ChartJS.register(
  CategoryScale,
  LinearScale,
  LineElement,
  PointElement,
  BarElement,
  Filler,
  Title,
  ArcElement,
  Tooltip,
  Legend
);

const StatisticsView = ({ weightBreakdown, doneTrainings }) => {
  const options = {
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
          text: "Kilograms",
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
  const optionsL = {
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
          text: "Training load (kg lifted)",
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

  const labels = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];

  let apilabels = Object.keys(weightBreakdown);

  const data = {
    labels,
    datasets: [
      {
        label: "Dataset 2",
        data: apilabels.map((month) => weightBreakdown[month]),
        backgroundColor: "#C7D7FE",
      },
    ],
  };

  const options2 = {
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
  };

  const data2 = {
    labels: ["Red", "Blue"],
    datasets: [
      {
        label: "# of Votes",
        data: [doneTrainings["item1"], doneTrainings["item2"]],
        backgroundColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
        borderColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
        borderWidth: 1,
      },
    ],
  };
  const data3 = {
    labels: ["Red", "Blue"],
    datasets: [
      {
        label: "# of Votes",
        data: [40, 10],
        backgroundColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
        borderColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
        borderWidth: 1,
      },
    ],
  };
  const data4 = {
    labels: ["Red", "Blue"],
    datasets: [
      {
        label: "# of Votes",
        data: [30, 21],
        backgroundColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
        borderColor: ["#8098F9", "rgba(240, 240, 240, 1)"],
        borderWidth: 1,
      },
    ],
  };

  const dataL = {
    labels,
    datasets: [
      {
        fill: true,
        label: "Dataset 2",
        data: labels.map(() => faker.datatype.number({ min: 0, max: 10000 })),
        borderColor: "#8098F9",
        backgroundColor: "#8098F9",
      },
    ],
  };

  return (
    <div className={style.container}>
      <div className={style.header} style={{ marginBottom: 0 }}>
        <h2>Statistics</h2>
        <p>
          Check out how are you doing compared to your previous achievements
        </p>
      </div>
      <div style={{ borderBottom: "1px solid #D0D5DD", width: "100%" }} />
      <div className={style.content}>
        <div className={style.barChart}>
          <Bar options={options} data={data} />
        </div>
        <div className={style.donutsSection}>
          <div className={style.eachDonut}>
            <Doughnut options={options2} data={data2} />
          </div>
          <div className={style.eachDonut}>
            <Doughnut options={options2} data={data3} />
          </div>
          <div className={style.eachDonut}>
            <Doughnut options={options2} data={data4} />
          </div>
        </div>
      </div>
      <div className={style.bottomChart}>
        <Line options={optionsL} data={dataL} />
      </div>
    </div>
  );
};

export default StatisticsView;
