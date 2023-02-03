import style from "./training-add-view.module.css";
import TopHeader from "../../../../reusable/top-header";
import DetailsTraining from "./details-training";

const TrainingDetailsViewonlyView = () => {
  return (
    <div className={style.container}>
      <TopHeader
        title='Training'
        text='Training details provided below'
        href='/athlete/training/trainings'
      />
      <div className={style.name}>
        <h3>Plan</h3>
        <p>A plan meant for developing back and core</p>
      </div>
      <div className={style.choices}>
        <DetailsTraining ifDisabled={true} />
        <DetailsTraining ifDisabled={true} />
        <DetailsTraining ifDisabled={true} />
        <DetailsTraining ifDisabled={true} />
        <DetailsTraining ifDisabled={true} />
      </div>
      <div style={{ paddingTop: "1rem" }}>
        <div
          className='btn-toolbar'
          role='toolbar'
          aria-label='Toolbar with button groups'
        >
          <div
            className='btn-group me-2 w-auto flex-fill'
            role='group'
            aria-label='First group'
          >
            <button
              type='button'
              className='btn btn-primary'
              style={{
                backgroundColor: "#8098F9",
                color: "white",
                border: "1px solid #D0D5DD",
              }}
            >
              Close
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default TrainingDetailsViewonlyView;
