import style from "./add-plan-view.module.css";
import TopHeader from "../../reusable/top-header";
import ExerciseDropdown from "../../athlete/training/training-plans/training-details/exercise-dropdown";
import Button from "../../reusable/button";

const AddPlanView = () => {
  return (
    <div className={style.container}>
      <TopHeader
        title='Training plan'
        text='Please provide training plan info below'
        href='/trainer-plans'
      />
      <div className={style.name}>
        <h5>Title</h5>
        <div className='input-group mb-3'>
          <input
            type='text'
            className='form-control'
            placeholder='Add name'
            aria-label='Username'
            aria-describedby='basic-addon1'
          />
        </div>
        <h5>Description</h5>
        <div className='input-group'>
          {/*<span className="input-group-text">With textarea</span>*/}
          <textarea
            className='form-control'
            aria-label='With textarea'
            placeholder='Description'
          />
        </div>
        <h5 style={{ marginTop: "1rem" }}>Training</h5>
        <div className='input-group mb-3'>
          <select className='form-select' id='inputGroupSelect01'>
            <option selected>Select particular training</option>
            <option value='1'>One</option>
            <option value='2'>Two</option>
            <option value='3'>Three</option>
          </select>
        </div>
        <h5>Training</h5>
        <div className='input-group mb-3'>
          <select className='form-select' id='inputGroupSelect01'>
            <option selected>Select particular training</option>
            <option value='1'>One</option>
            <option value='2'>Two</option>
            <option value='3'>Three</option>
          </select>
        </div>
        <h5>Training</h5>
        <div className='input-group mb-3'>
          <select className='form-select' id='inputGroupSelect01'>
            <option selected>Select particular training</option>
            <option value='1'>One</option>
            <option value='2'>Two</option>
            <option value='3'>Three</option>
          </select>
        </div>
        <h5>Training</h5>
        <div className='input-group mb-3'>
          <select className='form-select' id='inputGroupSelect01'>
            <option selected>Select particular training</option>
            <option value='1'>One</option>
            <option value='2'>Two</option>
            <option value='3'>Three</option>
          </select>
        </div>
      </div>
      <div className={style.buttons}>
        <Button
          iconSrc='/thumbnails/remove-circle-outline.svg'
          borderValue='none'
          backgroundColorValue='#D92D20'
          isHoveringColor='#FFB2B2'
          extraStyleType='color'
          extraStyleValue='#8098F9'
        />
        <Button
          iconSrc='/thumbnails/add-circle-outline.svg'
          borderValue='none'
          backgroundColorValue='#8098F9'
          isHoveringColor='#C7D7FE'
          extraStyleType='color'
          extraStyleValue='#8098F9'
        />
      </div>
      <div className={style.bottomInput}>
        <div style={{ width: "49%" }}>
          <h5>Weeks</h5>
          <select className='form-select' aria-label='Default select example'>
            <option selected>Open this select menu</option>
            <option value='1'>One</option>
            <option value='2'>Two</option>
            <option value='3'>Three</option>
          </select>
        </div>
        <div style={{ width: "49%" }}>
          <h5>Price</h5>
          <div className='mb-3'>
            <input
              type='number'
              className='form-control'
              id='exampleFormControlInput1'
              placeholder='123'
            />
          </div>
        </div>
      </div>
      <div className={style.bottomInput}>
        <div style={{ width: "49%" }}>
          <h5>Language</h5>
          <select className='form-select' aria-label='Default select example'>
            <option selected>Open this select menu</option>
            <option value='1'>One</option>
            <option value='2'>Two</option>
            <option value='3'>Three</option>
          </select>
        </div>
        <div style={{ width: "49%" }}>
          <h5>Skill level</h5>
          <select className='form-select' aria-label='Default select example'>
            <option selected>Open this select menu</option>
            <option value='1'>One</option>
            <option value='2'>Two</option>
            <option value='3'>Three</option>
          </select>
        </div>
      </div>
      <div className={style.container}>
        <h5>Status</h5>
        <div className='input-group mb-3'>
          <select className='form-select' id='inputGroupSelect01'>
            <option selected>Select particular training</option>
            <option value='1'>One</option>
            <option value='2'>Two</option>
            <option value='3'>Three</option>
          </select>
        </div>
      </div>
      <div style={{ marginLeft: "1rem", marginRight: "0.5rem" }}>
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
                backgroundColor: "#F5F5F5",
                color: "black",
                border: "1px solid #D0D5DD",
              }}
            >
              Cancel
            </button>
          </div>
          <div
            className='btn-group me-2 w-auto flex-fill'
            role='group'
            aria-label='Third group'
          >
            <button
              type='button'
              className='btn btn-info'
              style={{
                backgroundColor: "#8098F9",
                color: "white",
                border: "none",
              }}
            >
              Add
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AddPlanView;
