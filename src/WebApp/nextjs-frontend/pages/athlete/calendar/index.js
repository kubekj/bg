import CalendarView from "../../../components/athlete-view/athlete-calendar/calendar-view";
import Athlete from "../../../components/layouts/Athlete";
import {getSession} from "next-auth/react";


// export async function getServerSideProps(context) {
//   const session = await getSession({req: context.req});

// if (!session) {
//   return {
//     redirect: {
//       destination: "/auth/login",
//       permanent: false,
//     },
//   };
// }
//
//   return {
//     props: { jwt: session.jwt },
//   };
// }

const AthleteCalendar = ({jwt}) => {
  return <CalendarView />;
};

export default AthleteCalendar;

AthleteCalendar.layout = Athlete;
