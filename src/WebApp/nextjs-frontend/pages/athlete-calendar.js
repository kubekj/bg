import style from "../styles/athlete-main-page.module.css";
import DefaultLeftPane from "../components/reusable-comps/default-left-pane";
import CalendarView from "../components/athlete-view/athlete-calendar/calendar-view";

const AthleteCalendar = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD", width:"350px"}}>
                <DefaultLeftPane />
            </div>
            <CalendarView />
        </div>
    );
}

export default AthleteCalendar;