# JoystickMouse
\documentclass[conference]{IEEEtran}
\IEEEoverridecommandlockouts

\usepackage[utf8]{inputenc}
\usepackage{graphicx}
\usepackage{datetime}
\usepackage{hyperref}
\hypersetup{
    colorlinks=true,
    linkcolor=blue,
    filecolor=magenta,      
    urlcolor=cyan,
    pdftitle={Overleaf Example},
    pdfpagemode=FullScreen,
    }

\author{Frederic Lai - 100748388, James Pham - 100741773}
\title{Computer Mouse with Analog Stick (Assignment 1) \\\vspace*{20pt} \normalsize  \today{}}

\begin{document}

\maketitle

\section{Project Description}
\par{Our product is designed for people who would like to game with one hand whether it be from a disability, an injury, or just for convenience. In order to be able to meet those needs we created a computer mouse packed with all the necessary inputs for a simple first-person shooter game. Adding an analog stick onto the side of the mouse along with the side mouse buttons on a typical mouse should provide the player with the inputs to play a simple first-person shooter with only one hand. Although that is our main target, we believe that our product can have alternative uses evident from other similar products. Other mice that are similar have analog sticks that are fully rebindable and we believe that our mouse will serve well for binds in either gaming or productivity. First person shooter players that play with one hand typically utilize the many single-handed controllers that exist on the market. Most gamers especially PC gamers would prefer to use a mouse for PC shooters and thus we believe that our product would be able to fill that void for one-handed gamers on PC. 

An article from a website dedicated to one-handed accessibility (\ref{1.1}) talks about the gaming peripherals of a one-handed gamer. To quickly summarize, this particular person who plays games with one hand utilizes a handful of peripherals as well as software and rebinds a number of them to perform different tasks such as a racing sim foot pedal is rebinded for using potions in certain games as an example. With our product, hopefully we can reduce the amount of software or peripherals required to perform those tasks by having as much as those additional needed inputs packed into the computer mouse. 

Another website reviews gaming mice for first person shooter games (\ref{1.2}) and this is useful information as we're also gearing our mouse towards first person shooter players. Some common trends I noticed in the mice talked about in the review are the fact that most of them are built to be light, most of them are wireless, and there's an emphasis on low latency. Obviously comfort is also a major concern as nobody would want to use a mouse that's extremely uncomfortable. Even though comfort is important I noticed that none of these mice that first person shooter players use are vertical mice. Taking all of this into account our mouse will be more traditional, to make our mouse lighter we will have it wired and latency all depends on the sensor.


}

\section{System Architecture and Prototypes}

\par{
Our initial product circuit shown in \textbf{Fig. 1.} features only the basic mouse buttons with 2 side buttons and the joystick which is substituted with potentiometers in the circuit to act as the XY plane that the joystick would be in. When idle the current passes through the button and straight to ground so nothing happens. Once the button is pressed, the current alternates and enters the wire that's attached to the Arduino. Any excessive current passes through the resistor to prevent overloading the components. After the inputs are received by the Arduino, it communicates with the computer and the output that the player will see is whichever input they initially put in, such as: if they hit mouse 1 in a shooter then they would probably see the output of their character shooting something in the game. That's how the circuit itself works.

\begin{figure}[htp]
    \centering
    \includegraphics[width=8cm]{circuit.png}
    \caption{Our simulated product circuit}
    \label{fig:Circuit}
\end{figure}

As for the system architecture, we have the user inputting commands to the system. Everything they would input would be through the mouse. The mouse has a multitude of inputs such as the buttons, the sensor, and the analog stick. Each of those communicate with the Arduino which would then translate into actions on the computer and those actions are the outputs/visual feedback that the user would then experience.

\begin{figure}[htp]
    \centering
    \includegraphics[width=8cm]{systemarchitecture.png}
    \caption{System Architecture}
    \label{fig:Architecture}
\end{figure}
}

In \textbf{Fig. 2.}, this is a rough sketch of roughly what we had thought for our product. Similar to the circuit simulation, this sketch lacks buttons as our initial idea only had the basic mouse buttons as mentioned earlier. The shape and placements are also very rough but will be adjusted in the future to see what is the most ergonomic.

\begin{figure}[htp]
    \centering
    \includegraphics[width=8cm]{joystickmouse.png}
    \caption{Rough sketch of our product idea}
    \label{fig:Sketch}
\end{figure}

\begin{figure}[htp]
    \centering
    \includegraphics[width=8cm]{paperprototype.jpg}
    \caption{A paper prototype of what we envision for our product}
    \label{fig:Prototype}
\end{figure}

\section{Sources}

\subsection
{
\label{1.1}
One-Handed Gaming – OneArmedGraphics. \href{https://www.onearmedgraphics.com/chronic-pain/one-handed-gaming/}{https://www.onearmedgraphics.com/chronic-pain/one-handed-gaming/}. Accessed 28 Sept. 2022.
}

\subsection{
\label{1.2}
“The Best FPS Mouse - Fall 2022: Mice Reviews.” RTINGS.Com, \href{https://www.rtings.com/mouse/reviews/best/fps}{https://www.rtings.com/mouse/reviews/best/fps}. Accessed 28 Sept. 2022.
}

\subsection{
\label{1.3}
Gushiken, Sho, et al. “Operability Improvement of Joystick Mouse by Using a Microcomputer.” Electronics and Communications in Japan, vol. 98, no. 1, Jan. 2015, pp. 23–30. DOI.org (Crossref), \href{https://doi.org/10.1002/ecj.11618}{https://doi.org/10.1002/ecj.11618}.
}

\subsection{
\label{1.4}
Gerling, Kathrin M., et al. “Measuring the Impact of Game Controllers on Player Experience in FPS Games.” Proceedings of the 15th International Academic MindTrek Conference on Envisioning Future Media Environments - MindTrek ’11, ACM Press, 2011, p. 83. DOI.org (Crossref), \href{https://doi.org/10.1145/2181037.2181052}{https://doi.org/10.1145/2181037.2181052}.
}

\subsection{
\label{1.5}
Google. (n.d.). US20100045600A1 - combined mouse and Joystick Input device. Google Patents. Retrieved September 27, 2022, from \href{https://patents.google.com/patent/US20100045600A1/en}{https://patents.google.com/patent/US20100045600A1/en} 
}

\end{document}
