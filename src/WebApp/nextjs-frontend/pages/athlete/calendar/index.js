import CalendarView from "../../../components/athlete/calendar/calendar-view";
import Athlete from "../../../components/layouts/Athlete";
import { getSession } from "next-auth/react";
import fetcher from "../../../lib/rest-api";

export async function getServerSideProps(context) {
  const session = await getSession({ req: context.req });

  if (!session) {
    return {
      redirect: {
        destination: "/auth/login",
        permanent: false,
      },
    };
  }

  const options = {
    headers: {
      Authorization: `Bearer ${session.jwt}`,
    },
  };

  const workouts = await fetcher("workouts/sessions", options);

  return {
    props: { workouts: workouts },
  };
}

const AthleteCalendar = ({ workouts }) => {
  return <CalendarView workouts={workouts} />;
};

export default AthleteCalendar;

AthleteCalendar.layout = Athlete;
