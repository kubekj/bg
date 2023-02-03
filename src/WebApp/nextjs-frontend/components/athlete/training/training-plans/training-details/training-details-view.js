import style from "./training-details-view.module.css";
import TopHeader from "../../../../reusable/top-header";
import BelowHeader from "../../../../reusable/below-header";
import BottomButtonsSection from "../../../../reusable/bottom-buttons-section";

const TrainingDetailsView = () => {
  const sampleData = [
    {
      id: 1,
      trainingName: "Push",
      duration: "2h",
      sets: "23",
    },
    {
      id: 2,
      trainingName: "Pull",
      duration: "1h 30min",
      sets: "13",
    },
    {
      id: 3,
      trainingName: "Split",
      duration: "48min",
      sets: "16",
    },
    {
      id: 4,
      trainingName: "Cardio",
      duration: "1h 10min",
      sets: "20",
    },
  ];

  return (
    <div className={style.container}>
      <div style={{ borderBottom: "1px solid #D0D5DD" }}>
        <TopHeader
          title='Training plan'
          text='Training plan details provided below'
          href='/athlete-apply-training'
        />
        <BelowHeader
          title='Healthy back'
          text='A plan meant dor developing back and core'
        />
      </div>
      <div className={style.contentTable}>
        <table style={{ width: "100vh" }}>
          <thead className={style.tHead}>
            <tr>
              <th className={style.thRegular}>Workout</th>
              <th className={style.thRegular}>Duration</th>
              <th className={style.thRegular}>Sets</th>
            </tr>
          </thead>
          <tbody>
            {sampleData.map((training) => {
              return (
                <tr key={training.id}>
                  <td
                    style={{
                      width: "33%",
                      borderBottom: "1px solid #D0D5DD",
                      paddingLeft: "2rem",
                    }}
                  >
                    {training.trainingName}
                  </td>
                  <td className={style.tdRegular}>{training.duration}</td>
                  <td className={style.tdRegular}>{training.sets}</td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
      <div className={style.bottomSection}>
        <BottomButtonsSection
          textL='Jan 6, 2022 - Jan 13, 2022'
          icoL='/thumbnails/calendar-number-outline.svg'
          bgL='#F5F5F5'
          hovL='#D0D5DD'
          colorL='black'
          textR='Apply plan'
          icoR='/thumbnails/checkmark-outline.svg'
          bgR='#8098F9'
          hovR='#C7D7FE'
          colorR='white'
        />
      </div>
    </div>
  );
};

export default TrainingDetailsView;
